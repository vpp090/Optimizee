const Materials = ({ materialsData }) => {
  // Check if authorsData is an array and not empty
  const isDataValid = Array.isArray(materialsData) && materialsData.length > 0;

  return (
    <div>
      {isDataValid ? (
        materialsData.map((material, index) => (
          <div key={index} className="text-start item-box mt-2">
            <div> Name: {material.Name}</div>
            <div>
              URL: <a href={material.Url}>Document url</a>
            </div>
            <div>Publisher: {material.Publisher || "N/A"}</div>
          </div>
        ))
      ) : (
        <p>No materials data available</p> // Or any other fallback content
      )}
    </div>
  );
};

export default Materials;
