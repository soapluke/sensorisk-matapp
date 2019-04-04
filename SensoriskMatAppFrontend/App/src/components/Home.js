import React from 'react';
import { connect } from 'react-redux';
import SearchSurvey from '../components/SearchSurvey';
import '../styles/content-container.css';

export const Home = () => {
    return (
        <div className="content-container__search">
            <SearchSurvey />
        </div>
    )
};