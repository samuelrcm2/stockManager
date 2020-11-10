import React, { useEffect, useState } from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import Modal from '../Generic/Modal/Modal';
import StockTable from "./StockTable/StockTable";
import * as Constants from "../Generic/Constants"
import * as stockItemsActions from "../../Store/StockItems/StockItemsActions";
//CSS
import Button from "@material-ui/core/Button";
import Paper from "@material-ui/core/Paper";
import FormBuilder from "../Generic/FormBuilder/FormBuilder";
import useStyles from "./StockStyle";

const emptyStockItem = {
    name: "",
    amount: 0,
    unitPrice: 0,
    id: null
}

const Stock = (props) => {
  const {
    allStockItems,
    filteredStockItems
  } = props;

  const classes = useStyles();
  const [ModalFunction, setModalTypeState] = useState(Constants.editionFlag);
  const [stockItemInModal, setstockItemInModal] = useState(emptyStockItem);
  const [isModalOpen, setModalState] = useState(false);

  useEffect(() => {
    props.getAllStockItems();
  }, []);

  const SearchStockitemForm = {
    forms: [
      {
        type: "TextField",
        id: "stock-item-search",
        label: "Stock Item Name",
        inputType: "text",
        defaultValue: "",
        onChange: (value) => props.setFilteredStockItems(filterStockItemByName(value)),
        hasTooltip: false,
        isVisible: true,
      }
    ],
    hasSwitch: false,
    hasButtom: false,
  };

  const EditStockItemForm = {
    forms: [
        {
            type: "TextField",
            id: "stock-item-name-edit-modal",
            label: "Stock Item Name",
            inputType: "text",
            defaultValue: stockItemInModal.name,
            onChange: (value) => setStockItemInModalName(value),
            hasTooltip: false,
            isVisible: true,
        },
        {
            type: "TextField",
            id: "stock-item-amount-edit-modal",
            label: "Amount",
            inputType: "number",
            defaultValue: stockItemInModal.amount,
            onChange: (value) => setStockItemInModalAmount(value),
            hasTooltip: false,
            isVisible: true,
        },
        {
            type: "TextField",
            id: "stock-item-unit-price-edit-modal",
            label: "Unit Price",
            inputType: "number",
            defaultValue: stockItemInModal.unitPrice,
            onChange: (value) => setStockItemInModalUnitPrice(value),
            hasTooltip: false,
            isVisible: true,
        },
    ],
    hasSwitch: false,
    hasButtom: false,
  }

  const setStockItemInModalName = name => 
    setstockItemInModal({...stockItemInModal, name })

  const setStockItemInModalAmount = amount => 
    setstockItemInModal({...stockItemInModal, amount: Number(amount) })

  const setStockItemInModalUnitPrice = unitPrice => 
    setstockItemInModal({...stockItemInModal, unitPrice: Number(unitPrice) })
  

  const handleStockItemCancelInModal = () => {
    setstockItemInModal(emptyStockItem)
    setModalState(false)
  }

  const handleStockItemEdition = () => {
    props.editStockItem(stockItemInModal)
    handleStockItemCancelInModal()
  }

  const handleStockItemAddition = () => {
    props.addStockItem(stockItemInModal)
    handleStockItemCancelInModal()
  }

  const handleStockItemDeletion = () => {
    props.deleteStockItem(stockItemInModal.id)
    handleStockItemCancelInModal()
  }

  const ModalBody = 
     ModalFunction !== Constants.deletionFlag ? (
        <div className={classes.paper}>
          <FormBuilder formProps={EditStockItemForm}/> 
            <div className={classes.modalContent}> 
          <span>
            <Button
              variant="contained"
              color="primary"
              onClick={() => ModalFunction === Constants.editionFlag ? handleStockItemEdition() : handleStockItemAddition()}
            >
              {ModalFunction === Constants.editionFlag ? "Edit" : "Save"}
            </Button>
          </span>
          <span>
            <Button
              variant="contained"
              color="primary"
              onClick={() => handleStockItemCancelInModal()}
            >
              Cancel
            </Button>
          </span>
            </div>
          </div>) : (    
      <div className={classes.paper}>
        <div className={classes.modalContent}>
      <p id="simple-modal-description">
       {Constants.deletionModalMessage(stockItemInModal.name)}
      </p>
        </div>
      <div className={classes.modalContent}>           
          <span>
            <Button
              variant="contained"
              color="primary"
              onClick={() => handleStockItemDeletion()}
            >
              Delete
            </Button>
          </span>
          <span>
            <Button
              variant="contained"
              color="primary"
              onClick={() => handleStockItemCancelInModal()}
            >
              Cancel
            </Button>
          </span>
          </div>
    </div>)


  const openEditModal = (stockItem) => {
    setstockItemInModal(stockItem)
    setModalTypeState(Constants.editionFlag)
    setModalState(true)
  }

  const openAddModal = () => {
    setstockItemInModal(emptyStockItem)
    setModalTypeState(Constants.additionFlag)
    setModalState(true)
  }

  const openDeleteModal = (stockItem) => {
    setstockItemInModal(stockItem)
    setModalTypeState(Constants.deletionFlag)
    setModalState(true)
  }

  const filterStockItemByName = (stockItemName) => {
    let filteredStockItems = []

    if (allStockItems) 
        filteredStockItems = allStockItems.filter(s => s.name.includes(stockItemName))

    return filteredStockItems
  }

  return (
      <div className={classes.root}>
        <Paper>
        <h2 className={classes.title}>Sotock Manager</h2>
        <div className={classes.form}><FormBuilder formProps={SearchStockitemForm} /></div>
          <div className={classes.table}>
            <StockTable stockItems={filteredStockItems} onEditClick={(stockItem) => openEditModal(stockItem)}
              onDeleteClick={(stockItem) => openDeleteModal(stockItem)}/>
          </div>
            <span className={classes.addBotton}>
            <Button
              variant="contained"
              color="primary"
              onClick={() => openAddModal()}
            >
              Add Stock Item
            </Button>
          </span>
        </Paper>
        {isModalOpen && (<div className={classes.modal}><Modal body={ModalBody} open={isModalOpen} /></div>)}
      </div>
  );
};

const mapStateToProps = (state) => ({
  allStockItems: state.stockItems.allStockItems,
  filteredStockItems: state.stockItems.filteredStockItems,

});

const mapDispatchToProps = (dispatch) => {
  return bindActionCreators(stockItemsActions, dispatch);
};

export default connect(mapStateToProps, mapDispatchToProps)(Stock);