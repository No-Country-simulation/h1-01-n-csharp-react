import style from './Login.module.css'

function Login() {
  return (
    <div className={style.containerLogin}>
        <div>
            <input type="text" placeholder='Usuario'/>
        </div>
        <div>
            <input type="password" placeholder='Contraseña'/>
        </div>
    </div>
  )
}

export default Login