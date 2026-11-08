import axios from 'axios'

const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL || 'http://localhost:5080/api',
  headers: { 'Content-Type': 'application/json' },
})

export const serviceApi = {
  getAll: async () => (await api.get('/services')).data,
  getById: async (id) => (await api.get(`/services/${id}`)).data,
}

export const bookingApi = {
  create: async (payload) => (await api.post('/bookings', payload)).data,
}

export default api
