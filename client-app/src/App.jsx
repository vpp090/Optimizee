import "./App.css";
import { BrowserRouter as Router } from "react-router-dom";
import { Route, Routes, Navigate } from "react-router-dom";
import Home from "./layout/home/home";
import Topic from "./layout/topic/topic";
import Subtopics from "./layout/subtopics/subtopics";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate replace to="/home" />} />
        <Route path="/home" element={<Home />} />
        <Route path="/topic" element={<Topic />} />
        <Route path="/subtopics" element={<Subtopics />} />
      </Routes>
    </Router>
  );
}

export default App;
