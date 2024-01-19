using ArtificialIntel.Repos.Contracts;
using App.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;


namespace ArtificialIntel.Application.Features.Commands.ResponseWriter
{
    public class ResponseWriterCommandHandler : IRequestHandler<ResponseWriterCommand, bool>
    {
        private readonly ICrossrefRepo _repo;
        private readonly ILogger<ResponseWriterCommandHandler> _logger;

        public ResponseWriterCommandHandler(ICrossrefRepo repo, ILogger<ResponseWriterCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> Handle(ResponseWriterCommand request, CancellationToken cancellationToken)
        {
            try
            {


                List<Author> authors = new();
                List<Material> materials = new();

                var result = request.Result.FirstOrDefault();

                foreach (var item in result.Message.Items)
                {
                    if (item.Authors == null) continue;

                    foreach (var aut in item.Authors)
                    {
                        var author = new Author
                        {
                            Name = aut.Name ?? aut.Given + " " + aut.Family,
                            Description = aut.Sequence
                        };

                        authors.Add(author);
                    }
                }

                await _repo.SaveAuthorToRedis(authors, request.SubTopic, request.RequestId);

                foreach (var item in result.Message.Items)
                {
                    var material = new Material
                    {
                        Url = item.URL ?? string.Empty,
                        Name = item.Title.FirstOrDefault() ?? string.Empty,
                        DOI = item.DOI ?? string.Empty,
                        Publisher = item.Publisher ?? string.Empty,
                        ReferenceCount = item.ReferenceCount
                    };

                    materials.Add(material);
                }

                await _repo.SaveMaterialToRedis(materials, request.SubTopic, request.RequestId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }
    }
}
