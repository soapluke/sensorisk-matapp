import axios from 'axios';
import { apiUrl } from '../constants/constants';

export const fetchSurveyIDFromCode = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/Search/GetSurveyFromCode/${id}`)
            .catch(error => {
                throw (error);
            });
    };
};