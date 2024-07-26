import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/Medic';

export const registerMedicUser = async (medicData) => {
  try {
    const response = await axios.post(`${BASE_URL}/RegisterMedicUser`, medicData, {
      headers: {
        'Content-Type': 'application/json-patch+json'
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error registering medic user:', error);
    throw error;
  }
};