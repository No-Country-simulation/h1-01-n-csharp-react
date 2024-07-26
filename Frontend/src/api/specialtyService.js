import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/Specialty';

export const getAllSpecialties = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllSpecialties`, {
      headers: {
        'Accept': 'text/plain'
      }
    });
    return response.data.data;
  } catch (error) {
    console.error('Error fetching specialties:', error);
    throw error;
  }
};