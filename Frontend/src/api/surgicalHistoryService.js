import axios from 'axios'

const BASE_URL = 'https://justinaapi.somee.com/api/SurgicalHistory'

// Obtener todos los tipos de cirugías
export const getAllSurgeryTypes = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllSurgeryTypes`, {
      headers: {
        'Accept': 'text/plain',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error fetching surgery types:', error)
    throw error
  }
}