import React from 'react';
import { Link } from 'react-router-dom';
import ListItemText from '@material-ui/core/ListItemText';
import '../styles/list.css';

const SurveyListItem = ({ id, title}) => {
    return (
        <Link className="list-item" to={`/view/${id}`} >
            <div>
                    <ListItemText primary={title} />
            </div>
        </Link>
    );
};

export default SurveyListItem;