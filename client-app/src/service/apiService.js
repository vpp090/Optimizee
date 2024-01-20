import axios from "axios";

const API_BASE_URL = "http://localhost:8000";

export const sendTopic = async (topic) => {
  try {
    const response = await axios.post(
      `${API_BASE_URL}/api/Optimal/SendOptimalRequest`,
      { topic }
    );

    return response.data;
  } catch (error) {
    console.log(error);
  }
};

export const sendCrossrefRequest = async (
  subtopic,
  rows,
  offset,
  requestId
) => {
  try {
    if (rows) rows = 10;
    if (offset) offset = 1;

    const data = {
      subTopics: [subtopic],
      rows: rows,
      offset: offset,
      requestId: requestId,
    };

    const response = await axios.post(
      `${API_BASE_URL}/api/Optimal/SendCrossrefRequest`,
      data
    );

    return response.data;
  } catch (error) {
    console.log(error);
  }
};
