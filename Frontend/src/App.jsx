import { Routes, Route } from 'react-router-dom'
import MainLayout from './layouts/MainLayout'
import HomePage from './pages/HomePage'
import ServicesPage from './pages/ServicesPage'
import CartPage from './pages/CartPage'
import LoginPage from './pages/LoginPage'
import RegisterPage from './pages/RegisterPage'
import DashboardPage from './pages/DashboardPage'
export default function App(){return <Routes><Route element={<MainLayout/>}><Route path="/" element={<HomePage/>}/><Route path="/services" element={<ServicesPage/>}/><Route path="/cart" element={<CartPage/>}/><Route path="/login" element={<LoginPage/>}/><Route path="/register" element={<RegisterPage/>}/><Route path="/dashboard" element={<DashboardPage/>}/><Route path="*" element={<HomePage/>}/></Route></Routes>}
