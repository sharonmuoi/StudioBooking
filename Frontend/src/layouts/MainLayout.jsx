import { Outlet } from 'react-router-dom'
import Navbar from '../components/Navbar'
export default function MainLayout() { return <><Navbar/><main><Outlet/></main><footer className="mt-20 border-t border-black/10 px-6 py-8 text-center text-xs text-neutral-500">© {new Date().getFullYear()} StudioBooking. Nền tảng đặt lịch studio.</footer></> }
