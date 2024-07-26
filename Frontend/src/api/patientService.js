import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/Patient';

export const registerPatientUser = async (patientData) => {
  try {
    const response = await axios.post(`${BASE_URL}/RegisterPatientUser`, patientData, {
      headers: {
        'Content-Type': 'application/json-patch+json'
      }
    });
    return response.data;
  } catch (error) {
    console.error('Error registering patient user:', error);
    throw error;
  }
};