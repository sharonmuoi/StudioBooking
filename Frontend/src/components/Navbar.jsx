import { Camera, ShoppingBag, Menu } from 'lucide-react'
import { Link, NavLink } from 'react-router-dom'

const navClass = ({ isActive }) => `text-sm transition hover:text-bronze ${isActive ? 'text-bronze' : 'text-neutral-700'}`
export default function Navbar() {
  return <header className="sticky top-0 z-30 border-b border-black/10 bg-sand/95 backdrop-blur">
    <div className="mx-auto flex max-w-7xl items-center justify-between px-6 py-4">
      <Link to="/" className="flex items-center gap-2"><span className="grid h-9 w-9 place-items-center rounded-full bg-ink text-sand"><Camera size={18}/></span><span className="font-display text-xl font-bold tracking-tight">STUDIO<span className="text-bronze">BOOKING</span></span></Link>
      <nav className="hidden items-center gap-8 md:flex"><NavLink to="/" className={navClass}>Trang chủ</NavLink><NavLink to="/services" className={navClass}>Dịch vụ</NavLink><NavLink to="/dashboard" className={navClass}>Quản lý</NavLink></nav>
      <div className="flex items-center gap-3"><Link to="/cart" className="rounded-full border border-black/15 p-2 hover:bg-white" aria-label="Giỏ hàng"><ShoppingBag size={18}/></Link><Link to="/login" className="hidden rounded-full bg-ink px-5 py-2.5 text-sm text-white hover:bg-neutral-700 sm:block">Đăng nhập</Link><button className="md:hidden" aria-label="Mở menu"><Menu/></button></div>
    </div>
  </header>
}
