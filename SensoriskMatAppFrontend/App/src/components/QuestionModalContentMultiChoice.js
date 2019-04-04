import React from 'react';
import Checkbox from '@material-ui/core/Checkbox';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import Button from '@material-ui/core/Button';
import ClearIcon from '@material-ui/icons/Clear';
import IconButton from '@material-ui/core/IconButton';
import Divider from '@material-ui/core/Divider';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import '../styles/createsurvey.css';


class QuestionModalContentMultiChoice extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            currentOption: '',
            multiChoiceOptions: [],
            ownOption: false,
            oneOption: false,
        };
    }

    handleCheckToggle = async () => {
        await this.setState({ ownOption: !this.state.ownOption });
    };

    handleCheckOneOption = () => {
        this.setState({ oneOption: !this.state.oneOption });
    };

    onOptionChange = (e) => {
        const currentOption = e.target.value;
        this.setState(() => ({ currentOption }));
    };

    handleDeleteOption = async (option) => {
        let filteredState = this.state.multiChoiceOptions.filter(item => item !== option);
        this.props.onDeleteOption(option);
        await this.setState({ multiChoiceOptions: filteredState });
    }
    handleOption = (e) => {
        if (e.keyCode === 13) {
            this.onOptionSubmit()
        }
    }

    onOptionSubmit = async () => {
        await this.setState({ multiChoiceOptions: [...this.state.multiChoiceOptions, this.state.currentOption] });
        this.props.onOptionSubmit(this.state.multiChoiceOptions, this.state.ownOption);
        await this.setState({ currentOption: '' });
    };

    render() {

        return (
            <div>
                <FormControlLabel
                    control={
                        <Checkbox
                            onChange={this.handleCheckToggle}
                            checked={this.state.ownOption}
                        />
                    }
                    label={"Should respondants be able to add their own option?"}
                />
                <FormControlLabel
                    control={
                        <Checkbox
                            onChange={this.handleCheckOneOption}
                            checked={this.state.oneOption}
                        />
                    }
                    label={"The respondants can only choose one option"}
                />

                <OutlinedInput
                    type="text"
                    placeholder="Enter option..."
                    autoFocus
                    onChange={this.onOptionChange}
                    onKeyDown={this.handleOption}
                    value={this.state.currentOption}
                />
                <Button className="createsurvey__addoptionbtn" variant="contained" onClick={this.onOptionSubmit}>Add option</Button>
                <List>
                {
                    this.state.multiChoiceOptions.map((option) => {
                            return (
                                <div>
                                    <ListItem key={option}>
                                        <ListItemText primary={option} />
                                        <ListItemSecondaryAction>
                                            <IconButton
                                                value={option}
                                                onClick={(e) => {
                                                    e.preventDefault();
                                                    this.handleDeleteOption(option);
                                                }}>
                                                <ClearIcon />
                                            </IconButton>
                                        </ListItemSecondaryAction>
                                    </ListItem>
                                    <Divider />
                                </div>
                            );
                    })
                }
                </List>
            </div>

        );
    }
}

export default QuestionModalContentMultiChoice;
