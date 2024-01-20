const Authors = ({ authorsData }) => {
  // Check if authorsData is an array and not empty
  const isDataValid = Array.isArray(authorsData) && authorsData.length > 0;

  return (
    <div>
      {isDataValid ? (
        authorsData.map((author, index) => (
          <div key={index} className="text-start item-box mt-2">
            <div> Name: {author.Name}</div>
            <div>URL: {author.Url || "N/A"}</div>
            <div>Description: {author.Description || "N/A"}</div>
          </div>
        ))
      ) : (
        <p>No authors data available</p> // Or any other fallback content
      )}
    </div>
  );
};

export default Authors;
