import axios from 'axios'

const BASE_URL = 'https://justinaapi.somee.com/api/Pathology'

// Obtener todas las patologías
export const getAllPathologies = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllPathologies`, {
      headers: {
        'Accept': 'text/plain',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error fetching pathologies:', error)
    throw error
  }
}

// Obtener todas las categorías de patologías
export const getAllPathologyCategories = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllPathologyCategories`, {
      headers: {
        'Accept': 'text/plain',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error fetching pathology categories:', error)
    throw error
  }
}