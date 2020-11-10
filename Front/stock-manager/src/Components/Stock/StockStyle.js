import { createStyles, makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) =>
  createStyles({
    paper: {
        position: 'absolute',
        width: 400,
        backgroundColor: theme.palette.background.paper,
        border: '2px solid #000',
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
      },
    root: {
        width: '100%'
    },
    table: {
        paddingTop: "15px",
        paddingBottom: "15px",
        paddingLeft: "10%" ,
        paddingRight: "10%",
        maxHeight: "600px"
    },
    addBotton: {
        paddingRight: "10%",
        paddingBottom: "15px",
        display: "flex",
        justifyContent: "flex-end"
    },
    title: {
        paddingLeft: "25px",
        fontSize: "20px !important"
    },
    form: {
        paddingLeft: "25px !important",
    },
    modal: {
        margin: 0,
        position: "absolute",
        top: "50%",
        msTransform: "translateY(-50%)",
        transform: "translateY(-50%)",
    },
    modalContent: {
        display: "flex",
        justifyContent: "space-around"
    }
  })
);
