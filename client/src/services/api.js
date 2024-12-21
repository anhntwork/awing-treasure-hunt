import axios from "axios";

const BASE_URL = import.meta.env.VITE_BASE_URL;

export const apiRequest = async (endpoint, method = "GET", headers = {}, { body, params } = {}) => {
  try {
    const response = await axios({
      url: `${BASE_URL}${endpoint}`,
      method,
      headers,
      data: body,
      params,
    });

    if (response.status === 200 && response.data.isSuccess) {
      return response.data;
    } else {
      throw new Error(response.data.message || "Unknown API error");
    }
  } catch (error) {
    console.error("API Request Error:", error);
    throw error;
  }
};
