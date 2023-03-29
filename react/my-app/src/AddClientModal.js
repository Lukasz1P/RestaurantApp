import React,{Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class AddClientModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'Add', {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                
                clientName:event.target.clientName.value,
                clientSurName:event.target.clientSurName.value,
                clientPhone:event.target.clientPhone.value,
                clientEmail:event.target.clientName.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })
    }

    render(){
        return(
            <div className="containar">
<Modal
{...this.props}
size="lg"
aria-labelledby="contained-modal-title-cventer"
centered>
<Modal.Header>
    <Modal.Title>
        Add Client
    </Modal.Title>
</Modal.Header>
<Modal.Body>
    <Row>
        <Col sm={7}>
        <Form onSubmit={this.handleSubmit}>
           
                <Form.Group controlId="clientName">
                    <Form.Label>ClientName</Form.Label>
                    <Form.Control type="text" name="clientName" required placeholder="clientName"/>
            </Form.Group>

            <Form.Group controlId="clientSurName">
                    <Form.Label>ClientSurName</Form.Label>
                    <Form.Control type="text" name="clientSurName" required placeholder="clientSurName"/>
            </Form.Group>

            <Form.Group controlId="clientPhone">
                    <Form.Label>ClientPhone</Form.Label>
                    <Form.Control type="text" name="clientPhone" required placeholder="clientPhone"/>
            </Form.Group>

            <Form.Group controlId="clientEmail">
                    <Form.Label>ClientEmail</Form.Label>
                    <Form.Control type="text" name="clientEmail" required placeholder="clientEmail"/>
            </Form.Group>

            <Form.Group>
                <Button variant="primary" type="submit">
                    Add Client
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