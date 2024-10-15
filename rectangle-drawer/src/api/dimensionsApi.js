import axios from 'axios';

const API_URL = 'http://localhost:7076/rectangle';

export const getDimensions = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const updateDimensions = async (dimensions) => {
  try {
    const response = await axios.post(API_URL, dimensions);
    return response.data;
  } catch (error) {
    throw error;
  }
};