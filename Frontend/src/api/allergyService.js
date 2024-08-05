import axios from 'axios'

const BASE_URL = 'https://justinaapi.somee.com/api/Allergy'

// Obtener todas las alergias
export const getAllAllergies = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllAllergies`, {
      headers: {
        'Accept': 'text/plain',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error fetching allergies:', error)
    throw error
  }
}

// Obtener todas las categorías de alergias
export const getAllAllergyCategories = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllAllergyCategories`, {
      headers: {
        'Accept': 'text/plain',
      },
    })
    return response.data;
  } catch (error) {
    console.error('Error fetching allergy categories:', error)
    throw error
  }
}