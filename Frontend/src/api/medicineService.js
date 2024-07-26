import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/Medicine';

export const getAllMedicines = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllMedicines`, {
      headers: {
        'Accept': 'text/plain'
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching medicines:', error);
    throw error;
  }
};