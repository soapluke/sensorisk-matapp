import React from 'react';
import { connect } from 'react-redux';
import { fetchOrganisationFromID } from '../actions/profilePage';
import { fetchAllSurveysFromApi } from '../actions/surveys';
import Image from '../components/Image';
import SurveyListItem from '../components/SurveyListItem';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import Divider from '@material-ui/core/Divider';
import '../styles/content-container.css';
import '../styles/profilepage.css';

class ProfilePage extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            options:[]
        };
    }
    componentDidMount() {
        this.props.fetchOrganisationFromID(this.props.id);
        this.props.fetchAllSurveysFromApi(this.props.id);
    }

    render() {
        return (
            <div className="content-container">
                <Typography variant="h4" gutterBottom>My Profile</Typography>
                <div className="profilepage__content" >
                    <div className="profilepage__about">
                        <Paper>
                            <div className="profilepage__picture">
                                <Image id={this.props.id} />
                        </div>
                            <br />
                            <div className="profilepage__info">
                        <Typography variant="h4">{this.props.organisation.name}</Typography>
                        <Typography variant="h4">{this.props.organisation.email}</Typography>
                            <Typography variant="h4">Surveys {this.props.organisation.count}</Typography>
   
                            </div>
                        </Paper>
                </div>
                    <div className="profilepage__survey">
                        <Paper>
                        <Typography variant="h4">My surveys</Typography>
                            <List> {
                                this.props.surveys.map((survey) => {
                                        return (
                                            <div>
                                                <ListItem button>
                                                        <SurveyListItem key={survey.id} {...survey} />
                                                </ListItem>
                                                <Divider/>
                                            </div>
                                        )
                                    })
                            }
                            </List>
                        </Paper>
                    </div>
                </div>
                </div>
        )
    }
};
const mapStateToProps = (state, props) => ({
    // eslint-disable-next-line
    organisation: state.organisation,
    surveys: state.surveys,
    id: state.auth.id

});


const mapDispatchToProps = (dispatch) => ({
    fetchOrganisationFromID: (id) => dispatch(fetchOrganisationFromID(id)),
    fetchAllSurveysFromApi: (id) => dispatch(fetchAllSurveysFromApi(id))
});

export default connect(mapStateToProps, mapDispatchToProps)(ProfilePage);