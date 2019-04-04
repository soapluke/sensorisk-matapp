﻿import axios from 'axios';
import qs from 'qs';
import { apiUrl, originUrl } from '../constants/constants';

export const createSurvey = (survey, id) => {
    const data = {
        Title: survey.title,
        Description: survey.description,
        StartDate: survey.startDate,
        EndDate: survey.endDate,
        OrganisationID: id
    }
    console.log(data);
    return (dispatch) => {
        return axios.post(`${apiUrl}/Survey/AddSurvey`, data, {
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": `${originUrl}`
            }
        }).catch(error => {
            console.log(error);
        });
    };
};

export const testAPI = (data) => {
    return (dispatch) => {
        return axios.post('http://localhost:1337/api/values/post', data, {
            headers: {
                'content-type': 'application/json'
            }
        }).then(response => {
            console.log(response.data)
        })
        .catch(error => {
            console.log(error);
        });
    };
};

//export const testAPI = (data) => {
//    return (dispatch) => {
//        return axios({
//            method: 'post',
//            url: 'http://localhost:1337/api/values/post',
//            headers: { 'content-type': 'application/json' },
//            data
//        })
//    }
//};


//export const createSurveySuccess = (survey) => ({
//    type: 'CREATE_SURVEY',
//    survey
//});

export const fetchSurveys = (surveys) => ({
    type: 'FETCH_SURVEYS',
    surveys
});

export const fetchAllSurveysFromApi = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/Survey/GetSurveyFromOrganisation/${id}`)
            .then(response => {
                dispatch(fetchSurveys(response.data));
            })
            .catch(error => {
                throw (error);
            });
    };
};