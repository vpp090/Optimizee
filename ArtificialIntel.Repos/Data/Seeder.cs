﻿using App.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtificialIntel.Repos.Data
{
    public static class ResponseContextSeeder
    {
        public async static void SeedData(IMongoCollection<WorkspaceEntity> entityCollection)
        {
            bool exist = entityCollection.Find(e => true).Any();

            if (!exist)
            {
                await entityCollection.InsertManyAsync(GetEntities());
            }
        }

        public static IEnumerable<WorkspaceEntity> GetEntities()
        {
            return new List<WorkspaceEntity>()
            {
                new WorkspaceEntity()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Topic = "Topic 1",
                    SubTopics = new List<string> { "Subtopic1", "Subtopic2", "Subtopic3", "Subtopic4", "Subtopic5"},
                    Authors = new List<Author>
                    {
                        new Author
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            Name = "author1",
                            Description = "Description",
                            Url = "url here2ee",

                        },
                         new Author
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            Name = "author2",
                            Description = "Description21312",
                            Url = "url here2qq",
                        }
                    },
                    Discussions = new List<Discussion>
                    {
                        new Discussion
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            Name = "Discussion111",
                            Description = "Description24121",
                            Url = "url here2",
                        },

                        new Discussion
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            Name = "Discussion244",
                            Description = "Description2123",
                            Url = "url here2123",
                        }
                    },
                    Materials = new List<Material>
                    {
                        new()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            Name = "Material1",
                            Description = "Description2123",
                            Url = "url here2",
                        },
                        new()
                        {
                            Id =  ObjectId.GenerateNewId().ToString(),
                            Name = "Material2",
                            Description = "Description213",
                            Url = "url here21",
                        }
                    }
                },

            };
        }
    }
}
