import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/User';

export const authenticateUser = async (userData) => {
  try {
    const response = await axios.post(`${BASE_URL}/authenticate`, userData, {
      headers: {
        'Content-Type': 'application/json-patch+json'
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error authenticating user:', error);
    throw error;
  }
};