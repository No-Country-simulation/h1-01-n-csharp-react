import axios from 'axios';

const BASE_URL = 'http://justinaapi.somee.com/api/Admin';

export const getAllMedics = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllMedics`);
    return response.data;
  } catch (error) {
    console.error('Error fetching medics:', error);
    throw error;
  }
};

export const getAllPatients = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetAllPatients`);
    return response.data;
  } catch (error) {
    console.error('Error fetching patients:', error);
    throw error;
  }
};

export const getDeletedUsers = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/GetDeletedUsers`);
    return response.data;
  } catch (error) {
    console.error('Error fetching deleted users:', error);
    throw error;
  }
};

export const softDeleteUser = async (email) => {
  try {
    const response = await axios.delete(`${BASE_URL}/SoftDeleteUser/${email}`);
    return response.data;
  } catch (error) {
    console.error('Error soft deleting user:', error);
    throw error;
  }
};

export const hardDeleteUser = async (id) => {
  try {
    const response = await axios.delete(`${BASE_URL}/HardDeleteUser/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error hard deleting user:', error);
    throw error;
  }
};

export const restoreUser = async (id) => {
  try {
    const response = await axios.patch(`${BASE_URL}/RestoreUser/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error restoring user:', error);
    throw error;
  }
};