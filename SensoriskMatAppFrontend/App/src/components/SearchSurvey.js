import React from 'react';
import { connect } from 'react-redux';
import { history } from '../router/AppRouter';
import { fetchSurveyIDFromCode } from '../actions/searchSurvey';
import Paper from '@material-ui/core/Paper';
import InputBase from '@material-ui/core/InputBase';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import FormControl from '@material-ui/core/FormControl';
import FormHelperText from '@material-ui/core/FormHelperText';
import '../styles/content-container.css';
import '../styles/search.css';

class SearchSurvey extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            code: '',
            placeholder: 'Search for a survey with a four digit code',
            error: '',
        };
    }

    enterSearch = (e) => {
        if (e.keyCode === 13) {
            this.search()
        }
    }

    search = async () => {
        if (!isNaN(this.state.code)) {
            if (this.state.code.length === 4) {
                await this.props.fetchSurveyIDFromCode(this.state.code).then(response => {
                    if (response.data) {
                        history.push(`/view/${response.data}`);
                    }
                    else {
                        this.setState(() => ({
                            code: '',
                            error: 'There is no survey with this code'
                        }));
                    }
                }).catch(error => {
                    throw (error);
                });
            }
            else {
                this.setState(() => ({ error: 'A code must contain four digits' }));
            }
        }
        else {
            this.setState(() => ({
                code: '',
                error: 'A code can only contain digits'
            }));
        }
    }


    handleOnChange = (e) => {
        const code = e.target.value;
        this.setState(() => ({ error: '' }));
        this.setState(() => ({ code }));
        
    }
    render() {
        return (
            <div className="search__content">
                <FormControl>
                    <Paper className="search__content" elevation={1}>
                    <InputBase
                            className="search__input"
                            placeholder={this.state.placeholder}
                            onChange={this.handleOnChange}
                            onKeyDown={this.enterSearch}
                            value={this.state.code}
                    />
                        <IconButton onClick={this.search} aria-label="Search" className="search__icon">
                            <SearchIcon/>
                    </IconButton>
                    </Paper>
                    {this.state.error && <FormHelperText className="search__error">{this.state.error}</FormHelperText>}
                </FormControl>
            </div>
        )
    }
};

const mapDispatchToProps = (dispatch) => ({
    fetchSurveyIDFromCode: (id) => dispatch(fetchSurveyIDFromCode(id))
});

export default connect(undefined, mapDispatchToProps)(SearchSurvey);