import React from 'react';
import { connect } from 'react-redux';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import Divider from '@material-ui/core/Divider';
import SurveyListItem from '../components/SurveyListItem';
import '../styles/content-container.css';

export const SurveyList = (props) => {
    return (
        <div className="content-container">

                <List>
                    {
                        props.surveys.map((survey) => {
                            return (
                                <div>
                                    <ListItem><SurveyListItem key={survey.ID} {...survey} /></ListItem>
                                    <Divider />
                                </div>
                            )
                        })
                    }
                </List>

        </div>
    );
};

const mapStateToProps = (state) => {
    return {
        surveys: state.surveys
    };
};

export default connect(mapStateToProps)(SurveyList);