import BaseApi from "./baseApi";

export default class OrderApi {

    baseApi = new BaseApi('https://localhost:7190/api/');

    getOrderById = async(id) => {
        return await this.baseApi.getResource(`Order/GetOrderById?id=${id}`);
    }

    getAllOrders = async() => {
        return await this.baseApi.getResource('Order/GetAllOrders');
    }

    postOrder = async(order) => {
        return await this.baseApi.getResourceWithBody('Order/PostOrder', order);
    }
}