import "./workspace.css";

export default function Workspace() {
  return (
    <div className="container">
      <div className="row workspace-box">
        <div className="col-md-12 text-start">
          <h2>Your research topic: insert-topic-here</h2>
        </div>
      </div>
      <div className="row workspace-box text-start">
        <div className="com-md-12">
          <h3>Subtopics: </h3>
          <h4> subtopics here</h4>
        </div>
      </div>
      <div className="row">
        <div className="col-md-3 workspace-box">
          <div>
            <h4>Authors: </h4>
          </div>
          <div>Actual authors here</div>
        </div>
        <div className="col-md-6 workspace-box">
          <div>Notes here</div>
        </div>
        <div className="col-md-3 workspace-box">
          <div>
            <h4>Materials: </h4>
          </div>
          <div>Actual materials here</div>
        </div>
      </div>
    </div>
  );
}
