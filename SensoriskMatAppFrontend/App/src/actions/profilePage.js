import axios from 'axios';
import { apiUrl } from '../constants/constants';

export const fetchOrganisation = (organisation) => ({
    type: 'FETCH_ORGANISATION',
    organisation
});

export const fetchOrganisationFromID = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/Organisation/GetOrganisation/${id}`)
            .then(response => {
                dispatch(fetchOrganisation(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};

export const saveImagetoOrganisation = (image, id) => {
    console.log(id);
    const data = new FormData();
    data.append('file', image, id);

    return (dispatch) => {
        return axios.post(`${apiUrl}/Image/SaveImageToOrganisation`, data, {
            headers: {
                'Content-Type': `application/octet-stream`,
            }
        }).catch(error => {
            console.log(error);
        });
    };
};

//export const fetchImageFromOrganisation = (id) => {
//    return (dispatch) => {
//        return axios.get(`${apiUrl}/Image/GetImageFromOrganisation/${id}`)
//            .catch(error => {
//                throw (error);
//            });
//    };
//};

export const fetchImageFromOrganisation = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/Image/GetImageFromOrganisation/${id}`, {
            contentType: 'application/json',
            dataType: 'json'
        })
            .catch(error => {
                throw (error);
            });
    };
};