import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditClientModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'edit/'+this.props.clid,{
            method:'PATCH',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                
                clientName:event.target.clientName.value,
                clientSurName:event.target.clientSurName.value,
                clientPhone:event.target.clientPhone.value,
                clientEmail:event.target.clientEmail.value

            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Succesful');
        })
    }
    render(){
        return (
            <div className="container">

<Modal
{...this.props}
size="lg"
aria-labelledby="contained-modal-title-vcenter"
centered
>
    <Modal.Header>
        <Modal.Title id="contained-modal-title-vcenter">
            Edit Client
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={7}>
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="clientId">
                        <Form.Label>ClientId</Form.Label>
                        <Form.Control type="text" name="clientId" required
                        disabled
                        defaultValue={this.props.clid} 
                        placeholder="clientId"/>
                    </Form.Group>

                    <Form.Group controlId="clientName">
                        <Form.Label>ClientName</Form.Label>
                        <Form.Control type="text" name="clientName" required 
                        defaultValue={this.props.clname}
                        placeholder="clientName"/>
                    </Form.Group>

                    <Form.Group controlId="clientSurName">
                        <Form.Label>ClientSurName</Form.Label>
                        <Form.Control type="text" name="clientSurName" required 
                        defaultValue={this.props.clsurname}
                        placeholder="clientSurName"/>
                    </Form.Group>

                    <Form.Group controlId="clientPhone">
                        <Form.Label>ClientPhone</Form.Label>
                        <Form.Control type="text" name="clientPhone" required 
                        defaultValue={this.props.clphone}
                        placeholder="ClientPhone"/>
                    </Form.Group>

                    
                    <Form.Group controlId="clientEmail">
                        <Form.Label>ClientEmail</Form.Label>
                        <Form.Control type="text" name="clientEmail" required 
                        defaultValue={this.props.clemail}
                        placeholder="clientEmail"/>
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Update Client
                        </Button>
                    </Form.Group>
                </Form>
            </Col>
        </Row>
    </Modal.Body>
    
    <Modal.Footer>
        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
    </Modal.Footer>

</Modal>

            </div>
        )
    }

}