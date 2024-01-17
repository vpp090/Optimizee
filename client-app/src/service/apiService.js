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
