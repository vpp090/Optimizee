import "./notes.css";

const Note = ({ note, onChange, index }) => {
  return (
    <div className="sticky-note">
      <textarea
        value={note}
        onChange={(e) => onChange(e, index)}
        className="note-textarea"
      />
      <div className="text-end">
        <button className="btn btn-success btn-sm">Save Note</button>
      </div>
    </div>
  );
};

export default Note;
