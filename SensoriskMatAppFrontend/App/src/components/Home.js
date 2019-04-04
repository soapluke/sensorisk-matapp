import React from 'react';
import { connect } from 'react-redux';
import { testAPI } from '../actions/surveys'
import SearchSurvey from '../components/SearchSurvey';
import '../styles/content-container.css';

class Home extends React.Component {

    componentWillMount() {

        this.props.testAPI("korv");
    }

    render() {
        return (
            <div className="content-container__search">
                <SearchSurvey />
            </div>
        )
    }
};

const mapDispatchToProps = (dispatch) => ({
    testAPI: (data) => dispatch(testAPI(data))
});

export default connect(undefined, mapDispatchToProps)(Home);