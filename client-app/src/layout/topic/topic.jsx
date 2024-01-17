import { useState } from "react";
import { sendTopic } from "../../service/apiService";
import { useNavigate } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";

export default function Topic() {
  const [topic, setTopic] = useState("");
  const navigate = useNavigate();

  const handleInputChange = (event) => {
    setTopic(event.target.value);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const data = await sendTopic(topic);

      console.log(data);
      if (data.isSuccess) {
        navigate("/subtopics");
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="container text-start">
      <div className="row">
        <div className="col-md-12 text-start">
          <h2>Let's set up your ideal workspace</h2>
        </div>
      </div>
      <div className="row mt-5">
        <div className="col-sm-12 col-md-3">
          <h4>Main topic of your research: </h4>
        </div>
        <div className="col-sm-12 col-md-6 tm">
          <input
            type="text"
            className="form-control"
            placeholder="Enter the main topic of your research here"
            value={topic}
            onChange={handleInputChange}
          />
        </div>
      </div>
      <div className="row mt-3">
        <div className="col-md-8"></div>
        <div className="col-md-4">
          <button
            onClick={handleSubmit}
            className="btn btn-success mt-3 btn-lg"
          >
            Submit
          </button>
        </div>
      </div>
    </div>
  );
}
