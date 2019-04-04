import axios from 'axios';
import { apiUrl, originUrl } from '../constants/constants';

export const fetchCheckUser = (email) => {
    return (dispatch) => {
        const id = email.split('.').join('-');
        return axios.get(`${apiUrl}/Login/CheckUser/${id}`)
            .catch(error => {
                throw (error);
            });
    };
};

//export const fetchCheckPassword = (email1, password) => {
//    const email = email1.split('.').join('-');
//    return (dispatch) => {
//        console.log(email);
//        console.log(password);
//        return axios.get(`${apiUrl}/Login/CheckPassword/`, {
//                Email: email,
//                Password: password
//        }).catch(error => {
//            console.log(error);
//        });
//    };
//};

export const login = (id) => ({
    type: 'LOGIN',
    id
});

export const fetchCheckPassword = (email1, password) => {
    const email = email1.split('.').join('-');
    const data = {
                Email: email,
                Password: password
    }
    return (dispatch) => {
        return axios.post(`${apiUrl}/Login/CheckPassword`, data,
            {
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": `${originUrl}`
            }
            }
        ).then(response => {
            dispatch(login(response.data))
        }).catch(error => {
            console.log(error);
        });
    };
};

//export const fetchCheckPassword = (email1, password) => {
//    return (dispatch) => {
//        const email = email1.split('.').join('-');
//        return axios.get(`${apiUrl}/Login/CheckPassword`, {
//            Email: email,
//            Password: password
//        },
//            {
//                headers: { 'Content-Type': 'application/json' }
//            }
//        ).catch(error => {
//            throw (error);
//        });
//    };
//};