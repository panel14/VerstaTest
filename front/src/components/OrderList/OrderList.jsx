import React, { useState } from "react";
import './OrderList.scss'
import OrderForm from "../OrderForm/OrderForm";
import {format} from "date-fns";

const OrderList = ({list}) => {

    const [open, setOpen] = useState(-1);

    const parseItem = (item) => {
        const formated = format(item.pickUpDate, 'dd/MM/yyyy');
        return `Номер заказа: ${item.id}; От: ${item.senderCity}, ${item.senderAddress}; 
        До: ${item.recipientCity}, ${item.recipientAddress}; 
        Вес: ${item.weight}; Дата: ${formated}`;
    }

    const items = list.map((item, index) => {
        return(
            <li className="list-group-item" key={index}>
                {parseItem(item)}
                <button className="list-show-btn" onClick={() => setOpen(index)}>{'>'}</button>
            </li>
        )
    })

    console.log(list[open]);

    return(
        <div className="list-wrapper">
            <div>
                <h5>Список грузов</h5>
                {list.length > 0 
                ? <ui className="list-group">
                    {items}
                </ui>
                : <p>Нет грузов</p>}

            </div>
            {open != -1 && <OrderForm isReadOnly={true} values={list[open]}/>}        
        </div>
    )
}

export default OrderList;