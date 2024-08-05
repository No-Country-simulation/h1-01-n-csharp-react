import axios from 'axios'

const BASE_URL = 'https://justinaapi.somee.com/api/Patient'

// Registrar usuario paciente
export const registerPatientUser = async (patientData) => {
  try {
    const response = await axios.post(`${BASE_URL}/RegisterPatientUser`, patientData, {
      headers: {
        'Content-Type': 'application/json-patch+json',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error registering patient user:', error)
    throw error
  }
}

// Obtener médicos del paciente
export const getPatientMedics = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetPatientMedics`, {
      headers: {
        'Accept': 'text/plain',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error fetching patient medics:', error)
    throw error
  }
}