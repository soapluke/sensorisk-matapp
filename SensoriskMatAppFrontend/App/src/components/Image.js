import React from 'react';
import { connect } from 'react-redux';
import { saveImagetoOrganisation } from '../actions/profilePage';
import { fetchImageFromOrganisation } from '../actions/profilePage';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';
import DeleteIcon from '@material-ui/icons/Delete';
import CardMedia from '@material-ui/core/CardMedia';
import "../styles/image.css"

class Image extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            file: null,
            image: null
        };
    }

    componentDidMount = async () => {
        await this.props.fetchImageFromOrganisation(1).then(response => {
            console.log(response.data);
            if (response.data) {
                this.setState({
                    file: response.data
                })
          }
        })
        console.log(this.props.id);
    }
    componentWillUnmount = async () => {
        await this.props.saveImagetoOrganisation(this.state.image, this.props.id);
    }

    handleClearClick = () => {
        this.setState({
            file: null
        })
    }

    handleOnChange = (e) => {
        this.setState({
            file: URL.createObjectURL(e.target.files[0]), image: e.target.files[0]
        })
        console.log(this.state.file);
        console.log(this.state.image);
    }
    

render() {
        return (
            <div>

                <CardMedia
                    component="img"
                    alt="inget"
                   
                    height="140"
                    src={this.state.file}
                    title="Contemplative Reptile"
                />

                <IconButton aria-label="Delete" onClick={this.handleClearClick}>
                    <DeleteIcon />
                </IconButton>

                <input className="image__add" accept="image/*" id="icon-button-file" type="file" onChange={this.handleOnChange} />
                <label htmlFor="icon-button-file">
                    <IconButton color="primary" component="span">
                        <PhotoCamera />
                    </IconButton>
                </label>
            </div>
        );
    }
};
const mapDispatchToProps = (dispatch) => ({
    saveImagetoOrganisation: (image, id) => dispatch(saveImagetoOrganisation(image, id)),
    fetchImageFromOrganisation: (id) => dispatch(fetchImageFromOrganisation(id))
});

export default connect(undefined, mapDispatchToProps)(Image);

