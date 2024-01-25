import { useState } from 'react'
import './App.css'
import Navbar from './NavBar'
import Index from './pages/listar-veiculos/index'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
       <Navbar></Navbar>
       <Index></Index>
      </div>
    </>
  )
}

export default App
