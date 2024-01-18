import { useState, useEffect } from "react";
import "./subtopics.css"; // Ensure this path is correct

const Subtopics = () => {
  const subtopics = ["First Topic", "Second Topic", "Third Topic"];
  const [visibleIndex, setVisibleIndex] = useState(-1);

  useEffect(() => {
    const intervalId = setInterval(() => {
      setVisibleIndex((currentIndex) => {
        const nextIndex = currentIndex + 1;
        if (nextIndex < subtopics.length) {
          return nextIndex;
        } else {
          clearInterval(intervalId); // Clear interval when all subtopics have been shown
          return currentIndex;
        }
      });
    }, 1000); // Change the topic every second

    return () => clearInterval(intervalId);
  }, [subtopics.length]);

  return (
    <div className="container new-cont">
      <div className="row">
        <div className="col-md-12 text-start">
          <h2>
            Here are the most relevant subtopics we have identified for you
          </h2>
        </div>
      </div>
      <div className="row mt-5"></div>
      <div className="row mt-5"></div>
      <div className="row">
        {subtopics.map((topic, index) => (
          <div key={index} className="col-md">
            <div
              className={`subtopic-box ${
                index <= visibleIndex ? "visible" : ""
              }`}
            >
              {topic}
            </div>
          </div>
        ))}
      </div>
      <div className="row mt-5 text-end">
        <div className="col-md-8"></div>
        <div className="col-md-4">
          <button className="btn btn-success btn-lg">Next</button>
        </div>
      </div>
    </div>
  );
};

export default Subtopics;
