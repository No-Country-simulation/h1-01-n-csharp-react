import PropTypes from 'prop-types'
import style from './Modal.module.css'

const Modal = ({ children, isOpen, closeModal }) => {
  if (!isOpen) return null;

  return (
    <div className={style.modalContainer}>
      <div className={style.modalContent}>
        {children}
      </div>
      <div className={style.modalOverlay} onClick={closeModal}></div>
    </div>
  )
}

Modal.propTypes = {
  children: PropTypes.node,
  isOpen: PropTypes.bool.isRequired,
  closeModal: PropTypes.func.isRequired,
}

export default Modal