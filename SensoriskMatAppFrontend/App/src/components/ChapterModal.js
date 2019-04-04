import React from 'react';
import { connect } from 'react-redux';
import Button from '@material-ui/core/Button';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import { createChapter } from '../actions/chapters';
import '../styles/createsurvey.css';


class ChapterModal extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            currentChapter: '',
            chapterCount: 0,
            showModal: false
        };
    };

    onChapterChange = (e) => {
        const currentChapter = e.target.value;
        this.setState(() => ({ currentChapter }));
    };

    onCreateChapter = async () => {
        await this.setState({ chapterCount: this.state.chapterCount + 1 })
        this.props.createChapter(this.state.currentChapter, this.state.chapterCount);
        this.setState({ showModal: false });
    }

    handleOpenModal = () => {
        this.setState({ showModal: true });
    };

    handleCloseModal = () => {
        this.setState({ showModal: false });
    };

    render() {

        return (
            <div>
                <Button className="createsurvey__addchapterbtn" variant="contained" onClick={this.handleOpenModal}>Add chapter</Button>
                <Dialog
                    fullWidth={true}
                    maxWidth="sm"
                    aria-labelledby="chapter-modal-title"
                    open={this.state.showModal}
                    onClose={this.handleCloseModal}
                >
                    <DialogTitle id="chapter-modal-title">Add a chapter</DialogTitle>
                    <DialogContent>
                        <OutlinedInput
                            fullWidth={true}
                            type="text"
                            placeholder="Enter chapter name..."
                            autoFocus
                            labelWidth={0}
                            onChange={this.onChapterChange}
                        />
                        <DialogActions>
                                <Button variant="contained" onClick={this.onCreateChapter}>OK</Button>
                        </DialogActions>
                    </DialogContent>
                </Dialog>
            </div>
        );
    };
}

const mapDispatchToProps = (dispatch) => ({
    createChapter: (chapterName, id) => dispatch(createChapter(chapterName, id))
});

export default connect(undefined, mapDispatchToProps)(ChapterModal);
