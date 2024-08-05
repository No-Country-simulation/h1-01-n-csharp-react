import { useState, useEffect } from 'react'
import { getAllSpecialties } from '../api/specialtyService'
import { registerMedicUser } from '../api/medicService'
import { registerPatientUser } from '../api/patientService'

const useRegisterForm = (userType, onFieldFilled = () => { }) => {
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [dni, setDni] = useState('')
  const [license, setLicense] = useState('')
  const [specialtyId, setSpecialtyId] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')
  const [phoneNumber, setPhoneNumber] = useState('')
  const [birthDate, setBirthDate] = useState('')
  const [address, setAddress] = useState('')
  const [bloodType, setBloodType] = useState('')

  const [focusedField, setFocusedField] = useState('Selecciona tu rol')
  const [focusedStep, setFocusedStep] = useState('Paso 1')

  const handleFocus = (field) => {
    setFocusedField(field)
  }

  const handleStep = (step) => {
    setFocusedStep(step)
  }

  const [specialties, setSpecialties] = useState([])

  useEffect(() => {
    const fetchSpecialties = async () => {
      try {
        const data = await getAllSpecialties()
        setSpecialties(data)
      } catch (error) {
        console.error('Error fetching specialties:', error)
      }
    }

    fetchSpecialties()
  }, [])

  useEffect(() => {
    onFieldFilled({
      'Paso 1': firstName !== '' && lastName !== '',
      'Paso 2': dni !== '',
      'Paso 3': email !== '',
      'Paso 4': password !== '' && confirmPassword !== '',
      'Paso 5': phoneNumber !== '',
      'Paso 6': userType === 'Medic' ? license !== '' : true,
      'Paso 7': userType === 'Medic' ? specialtyId !== '' : true
    })
  }, [firstName, lastName, dni, email, password, confirmPassword, phoneNumber, license, specialtyId, userType])

  const handleSubmit = async (event) => {
    event.preventDefault()

    const commonData = {
      firstName,
      lastName,
      dni,
      email,
      password,
      phoneNumber,
    }

    if (userType === 'Medic') {
      const medicData = {
        ...commonData,
        license,
        specialtyId,
      }
      try {
        const response = await registerMedicUser(medicData)
        console.log('Medic registered successfully:', response)
      } catch (error) {
        console.error('Error registering medic:', error)
      }
    } else if (userType === 'Pacient') {
      const patientData = {
        ...commonData,
        birthDate,
        address,
        bloodType,
      }
      try {
        const response = await registerPatientUser(patientData)
        console.log('Patient registered successfully:', response)
      } catch (error) {
        console.error('Error registering patient:', error)
      }
    }
  }

  return {
    firstName, setFirstName,
    lastName, setLastName,
    dni, setDni,
    license, setLicense,
    specialtyId, setSpecialtyId,
    email, setEmail,
    password, setPassword,
    confirmPassword, setConfirmPassword,
    phoneNumber, setPhoneNumber,
    birthDate, setBirthDate,
    address, setAddress,
    bloodType, setBloodType,
    focusedField, handleFocus,
    focusedStep, handleStep,
    specialties,
    handleSubmit
  }
}

export default useRegisterForm