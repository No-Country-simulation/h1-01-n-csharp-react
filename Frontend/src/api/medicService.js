import axios from 'axios'

const BASE_URL = 'https://justinaapi.somee.com/api/Medic'

const token = localStorage.getItem('token')
const config = {
  headers: {
    Authorization: `Bearer ${token}`,
    'Content-Type': 'application/json-patch+json'
  }
}

// Registrar usuario médico
export const registerMedicUser = async (medicData) => {
  try {
    const response = await axios.post(`${BASE_URL}/RegisterMedicUser`, medicData, {
      headers: {
        'Content-Type': 'application/json-patch+json',
      },
    })
    return response.data
  } catch (error) {
    console.error('Error registering medic user:', error)
    throw error
  }
}

// Obtener datos del usuario médico
export const getMedicUserData = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetMedicUserData`, config)
    return response.data.data
  } catch (error) {
    console.error('Error getting medic user data:', error)
    throw error
  }
}

// Obtener emails de pacientes
export const getPatientsEmail = async (email) => {
  try {
    const response = await axios.get(`${BASE_URL}/GetPatientsEmail/${email}`, config)
    return response.data.data
  } catch (error) {
    console.error('Error getting patients email:', error)
    throw error
  }
}

// Añadir relación con paciente
export const addRelationshipWithPatient = async (patientEmail) => {
  try {
    const response = await axios.post(`${BASE_URL}/AddRelationshipWithPatient/${patientEmail}`, null, config)
    return response.data.data
  } catch (error) {
    console.error('Error adding relationship with patient:', error)
    throw error
  }
}

// Eliminar relación con paciente
export const deleteRelationshipWithPatient = async (patientEmail) => {
  try {
    const response = await axios.delete(`${BASE_URL}/DeleteRelationshipWithPatient/${patientEmail}`, config)
    return response.data.data
  } catch (error) {
    console.error('Error deleting relationship with patient:', error)
    throw error
  }
}

// Obtener pacientes del médico
export const getMedicPatients = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetMedicPatients`, config)
    return response.data.data;
  } catch (error) {
    console.error('Error getting medic patients:', error)
    throw error
  }
}

// Añadir registro médico
export const addMedRecord = async (patientId, medRecordData) => {
  try {
    const response = await axios.post(`${BASE_URL}/AddMedRecord/${patientId}`, medRecordData, config)
    return response.data.data
  } catch (error) {
    console.error('Error adding medical record:', error)
    throw error
  }
}

// Obtener registro médico
export const getMedRecord = async (patientId) => {
  try {
    const response = await axios.get(`${BASE_URL}/GetMedRecord/${patientId}`, config)
    return response.data.data
  } catch (error) {
    console.error('Error getting medical record:', error)
    throw error
  }
}

// Añadir historial clínico
export const addClinicalHistory = async (medRecordId, clinicalHistoryData) => {
  try {
    const response = await axios.post(`${BASE_URL}/AddClinicalHistory/${medRecordId}`, clinicalHistoryData, config)
    return response.data.data
  } catch (error) {
    console.error('Error adding clinical history:', error)
    throw error;
  }
}

// Obtener historiales clínicos
export const getClinicalHistories = async (medRecordId) => {
  try {
    const response = await axios.get(`${BASE_URL}/GetClinicalHistories/${medRecordId}`, config)
    return response.data.data
  } catch (error) {
    console.error('Error getting clinical histories:', error)
    throw error
  }
}

// Añadir cita médica
export const addAppointment = async (patientEmail, appointmentData) => {
  try {
    const response = await axios.post(`${BASE_URL}/AddAppointment/${patientEmail}`, appointmentData, config)
    return response.data.data
  } catch (error) {
    console.error('Error adding appointment:', error)
    throw error
  }
}

// Obtener citas médicas
export const getAppointments = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAppointments`, config)
    return response.data.data
  } catch (error) {
    console.error('Error getting appointments:', error)
    throw error
  }
}

// Añadir tratamiento
export const addTreatment = async (patientEmail, treatmentData) => {
  try {
    const response = await axios.post(`${BASE_URL}/AddTreatment/${patientEmail}`, treatmentData, config)
    return response.data.data
  } catch (error) {
    console.error('Error adding treatment:', error)
    throw error
  }
}

// Obtener tratamientos
export const getTreatments = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetTreatments`, config)
    return response.data.data
  } catch (error) {
    console.error('Error getting treatments:', error)
    throw error
  }
}