import React from "react";
import { FormProvider, useForm } from "react-hook-form";
import { getDateValidation, getNumValidation, getReqValidation} from "../../utils/inputValidation";
import TextField from "../shared/TextInput/TextInput"
import './OrderForm.scss'
import NumberInput from "../shared/NumberInput/NumberInput";
import DateInput from "../shared/DateInput/DateInput";

const OrderForm = ({isReadOnly, onSubmitHandle, values}) => {

    const methods = useForm();

    const onSubmit = methods.handleSubmit(data => {
        onSubmitHandle(data);
    })

    return(
        <div className="default-form">
            <h5>Форма груза</h5>
            <FormProvider {...methods}>
                <form 
                    onSubmit={e => e.preventDefault()} 
                    noValidate 
                    autoComplete="off">
                    
                    <TextField props={['SenderCity', 'Город отправителя', getReqValidation(), 'Укажите город...', isReadOnly, values.senderCity]}/>
                    <TextField props={['SenderAddress', 'Адрес отправителя', getReqValidation(), 'Укажите адрес...', isReadOnly, values.senderAddress]}/>
                    <TextField props={['RecipientCity', 'Город получателя', getReqValidation(), 'Укажите город...', isReadOnly, values.recipientCity]}/>
                    <TextField props={['RecipientAddress', 'Адрес получателя', getReqValidation(), 'Укажите город...', isReadOnly, values.recipientAddress]}/>

                    <NumberInput props={['Weight', 'Вес груза', getNumValidation(), 0.01, isReadOnly, values.weight]}/>
                    <DateInput props={['PickUpDate', 'Дата забора груза', getDateValidation(), isReadOnly, values.pickUpDate]}/>

                    {!isReadOnly && <button className="btn btn-light next-button" onClick={onSubmit}>Оформить заказ</button>} 
                </form>
            </FormProvider>
        </div>
    )
}

export default OrderForm;