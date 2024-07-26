import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/Pathology';

export const getAllPathologies = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllPathologies`, {
      headers: {
        'Accept': 'text/plain'
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching pathologies:', error);
    throw error;
  }
};