import React from 'react';
import { connect } from 'react-redux';
import Button from '@material-ui/core/Button';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogTitle from '@material-ui/core/DialogTitle';
import SurveyDatePicker from '../components/SurveyDatePicker';
import '../styles/createsurvey.css';

class SurveyForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            title: '',
            description: '',
            startDate: undefined,
            endDate: undefined,
            error: '',
            openConfirm: false
        };
    }

    handleOpenConfirm = (e) => {
        e.preventDefault();
        if (!this.state.title || !this.state.description) {
            this.setState(() => ({ error: 'Please provide title and description for the survey.' }));
        } else if (this.state.startDate === undefined || this.state.endDate === undefined) {
            this.setState(() => ({ error: 'Please provide a start date and end date for the survey.' }));
        } else if (this.props.chapters.length === 0) {
            this.setState(() => ({ error: 'Please add a chapter to the survey.' }));
        } else {
            this.setState({ openConfirm: true });
        }
    }

    handleCloseConfirm = () => this.setState({ openConfirm: false });

    onTitleChange = (e) => {
        const title = e.target.value;
        this.setState(() => ({ title }));
    }

    onDescriptionChange = (e) => {
        const description = e.target.value;
        this.setState(() => ({ description }));
    }

    onDateChange = (dates) => {
        this.setState({
            startDate: dates.startDate,
            endDate: dates.endDate
        });
        console.log(this.state.startDate, this.state.endDate);
    }

    onSubmit = async (e) => {
        e.preventDefault();
        this.handleCloseConfirm();
        this.setState(() => ({ error: '' }));
        await this.props.onSubmit({
            title: this.state.title,
            description: this.state.description,
            startDate: this.state.startDate,
            endDate: this.state.endDate
        });
        
    };

    render() {
        return (
                <div>
                    {this.state.error && <p>{this.state.error}</p>}
                    <OutlinedInput
                        className="createsurvey__input"
                        type="text"
                        placeholder="Survey title..."
                        autoFocus
                        labelWidth={0}
                        onChange={this.onTitleChange}
                    />
                    <TextField
                        className="createsurvey__textfield"
                        placeholder="Description for survey..."
                        multiline
                        rows="4"
                        fullWidth={true}
                        variant="outlined"
                        onChange={this.onDescriptionChange}
                    />
                    <SurveyDatePicker onDateChange={this.onDateChange}/>

                    <Button className="createsurvey__savesurveybtn" variant="contained" onClick={this.handleOpenConfirm}>Save Survey</Button>
                    <Dialog
                        open={this.state.openConfirm}
                        onClose={this.handleCloseConfirm}
                        aria-labelledby="alert-dialog-title"
                    >
                        <DialogTitle id="alert-dialog-title">{"Are you sure you want to save the survey?"}</DialogTitle>
                        <DialogActions>
                            <Button onClick={this.handleCloseConfirm} color="primary">
                                NO
                            </Button>
                            <Button onClick={this.onSubmit} color="primary" autoFocus>
                                YES
                            </Button>
                        </DialogActions>
                    </Dialog>
                </div>
        );
    }
}

const mapStateToProps = (state) => ({
    // eslint-disable-next-line
    chapters: state.chapters
});

export default connect(mapStateToProps)(SurveyForm);