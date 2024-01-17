import { Link } from "react-router-dom";
import welcomeImage from "../../assets/welcome.png";
import "bootstrap/dist/css/bootstrap.min.css";

export default function Home() {
  return (
    <>
      <div className="container">
        <div className="row align-items-center">
          <div className="col-md-6">
            <h2 className="text-start">Welcome to</h2>
            <h1 className="text-start">
              <strong>Optimizee!</strong>
            </h1>
            <p className="text-start">
              Optimizee enhances your research workflow, providing key tools
              essential for achieving excellence.
            </p>
            <p className="text-start">
              This solution is tailored to streamline and improve your research
              activities, ensuring superior outcomes in every phase of your
              scholarly work.
            </p>
          </div>
          <div className="col-md-6">
            <img src={welcomeImage} alt="Welcome" className="img-fluid" />
          </div>
        </div>
      </div>
      <div className="row">
        <div className="col-md-6"></div>
        <div className="col-md-4 text-end">
          <Link to="/topic" className="btn btn-success mt-3 btn-lg">
            Next
          </Link>
        </div>
        <div className="col-md-2"></div>
      </div>
    </>
  );
}
