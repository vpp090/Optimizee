import { startConnection, stopConnection } from "../../service/signalrservice";
import "./workspace.css";
import { useEffect, useState } from "react";
import Authors from "./authors";
import Materials from "./materials";
import Note from "../notes/Note";
import "./item-box.css";
import "bootstrap-icons/font/bootstrap-icons.css";

export default function Workspace() {
  const [authorsData, setAuthors] = useState([]);
  const [materialsData, setMaterials] = useState([]);
  const [connection, setConnection] = useState(null);
  const [notes, setNotes] = useState([]);

  const handleAddNote = () => {
    setNotes([...notes, "New note"]);
  };

  const handleNoteChange = (event, index) => {
    const updateNotes = notes.map((note, i) => {
      if (i === index) {
        return event.target.value;
      }

      return note;
    });

    setNotes(updateNotes);
  };

  useEffect(() => {
    const savedAuthors = localStorage.getItem("authorsData");
    const savedMaterials = localStorage.getItem("materialsData");

    if (savedAuthors && savedMaterials) {
      setAuthors(JSON.parse(savedAuthors));
      setMaterials(JSON.parse(savedMaterials));
    }

    const dataCon = startConnection((data) => {
      const aut = JSON.parse(data.authors);
      setAuthors(aut);

      localStorage.setItem("authorsData", data.authors);

      const mat = JSON.parse(data.materials);
      setMaterials(mat);

      localStorage.setItem("materialsData", data.materials);
    });

    setConnection(dataCon);

    return () => {
      stopConnection(dataCon);
    };
  }, []);

  return (
    <div className="container">
      <div className="row workspace-box">
        <div className="col-md-12 text-start">
          <h2>Your research topic: insert-topic-here</h2>
        </div>
      </div>
      <div className="row workspace-box text-start mt-4">
        <div className="com-md-12">
          <h3>Subtopics: </h3>
          <h4> subtopics here</h4>
        </div>
      </div>
      <div className="row mt-4">
        <div className="col-md-3 workspace-box me-5">
          <div className="text-start">
            <h4>Authors: </h4>
          </div>
          <Authors authorsData={authorsData} />
        </div>
        <div className="col-md-5 workspace-box me-5">
          <div className="row">
            <div className="col-md-2">
              <button onClick={handleAddNote} className="btn btn-outline-info">
                <i className="bi bi-clipboard-plus"></i>
              </button>
            </div>
            <div className="col-md-10"></div>
          </div>
          <div className="notes-section mt-3">
            {notes.map((note, index) => (
              <Note
                key={index}
                note={note}
                onChange={handleNoteChange}
                index={index}
              />
            ))}
          </div>
        </div>
        <div className="col-md-3 workspace-box">
          <div className="text-start">
            <h4>Materials: </h4>
          </div>
          <Materials materialsData={materialsData} />
        </div>
      </div>
      <div className="row mt-5 text-end">
        <div className="col-md-8"></div>
        <div className="col-md-4">
          <button
            //onClick={handleButtonClick}
            className="btn btn-success btn-lg"
          >
            Next
          </button>
        </div>
      </div>
    </div>
  );
}
