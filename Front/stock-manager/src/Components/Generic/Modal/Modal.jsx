import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';

const useStyles = makeStyles((theme) => ({
  paper: {
    position: 'absolute',
    width: 400,
    backgroundColor: theme.palette.background.paper,
    border: '2px solid #000',
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
  },
  modal: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
  },
}));

const GenericModal = (props) => {
  const classes = useStyles();
  return (
    <div>
      <Modal
        open={props.open}
        onClose={props.handleClose}
        className={classes.modal}
        aria-labelledby="modal-title"
        aria-describedby="modal-description"
      >
        {props.body}
      </Modal>
    </div>
  );
}

export default GenericModal;
