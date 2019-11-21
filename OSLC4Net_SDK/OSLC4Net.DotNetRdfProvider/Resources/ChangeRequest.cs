﻿/*******************************************************************************
 * Copyright (c) 2013 IBM Corporation.
 *
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * and Eclipse Distribution License v. 1.0 which accompanies this distribution.
 *
 * The Eclipse Public License is available at http://www.eclipse.org/legal/epl-v10.html
 * and the Eclipse Distribution License is available at
 * http://www.eclipse.org/org/documents/edl-v10.php.
 *
 * Contributors:
 *     Steve Pitschke  - initial API and implementation
 *******************************************************************************/

namespace OSLC4Net.Core.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OSLC4Net.Core.Attribute;
    using OSLC4Net.Core.Model;

    [OslcNamespace(CmConstants.CHANGE_MANAGEMENT_NAMESPACE)]
    [OslcResourceShape(title = "Change Request Resource Shape", describes = new string[] { CmConstants.TYPE_CHANGE_REQUEST })]
    public class ChangeRequest : AbstractResource
    {
        private readonly ISet<Link> _affectedByDefects = new HashSet<Link>();
        private readonly ISet<Link> _affectsPlanItems = new HashSet<Link>();
        private readonly ISet<Link> _affectsRequirements = new HashSet<Link>();
        private readonly ISet<Link> _affectsTestResults = new HashSet<Link>();
        private readonly ISet<Link> _blocksTestExecutionRecords = new HashSet<Link>();
        private readonly ISet<Uri> _contributors = new HashSet<Uri>(); // XXX - TreeSet<> in Java
        private readonly ISet<Uri> _creators = new HashSet<Uri>(); // XXX - TreeSet<> in Java
        private readonly ISet<string> _dctermsTypes = new HashSet<string>(); // XXX - TreeSet<> in Java
        private readonly ISet<Link> _implementsRequirements = new HashSet<Link>();
        private readonly ISet<Link> _relatedChangeRequests = new HashSet<Link>();
        private readonly ISet<Link> _relatedResources = new HashSet<Link>(); // TODO - Extension to point to any other OSLC resource(s).
        private readonly ISet<Link> _relatedTestCases = new HashSet<Link>();
        private readonly ISet<Link> _relatedTestExecutionRecords = new HashSet<Link>();
        private readonly ISet<Link> _relatedTestPlans = new HashSet<Link>();
        private readonly ISet<Link> _relatedTestScripts = new HashSet<Link>();
        private readonly ISet<string> _subjects = new HashSet<string>(); // XXX - TreeSet<> in Java
        private readonly ISet<Link> _testedByTestCases = new HashSet<Link>();
        private readonly ISet<Link> _tracksChangeSets = new HashSet<Link>();
        private readonly ISet<Link> _tracksRequirements = new HashSet<Link>();
        private readonly ISet<Uri> _rdfTypes = new HashSet<Uri>(); // XXX - TreeSet<> in Java

        private bool _approved;
        private bool _closed;
        private DateTime? _closeDate;
        private DateTime? _created;
        private string _description;
        private Uri _discussedBy;
        private bool _isFixedValue;
        private string _identifier;
        private bool _inProgress;
        private Uri _instanceShape;
        private DateTime? _modified;
        private bool _reviewed;
        private Uri _serviceProvider;
        private string _shortTitle;
        private string _status;
        private string _title;
        private bool _verified;

        public ChangeRequest() : base()
        {
            this._rdfTypes.Add(new Uri(CmConstants.TYPE_CHANGE_REQUEST));
        }

        public ChangeRequest(Uri about) : base(about)
        {
            this._rdfTypes.Add(new Uri(CmConstants.TYPE_CHANGE_REQUEST));
        }

        public void AddAffectedByDefect(Link affectedByDefect)
        {
            this._affectedByDefects.Add(affectedByDefect);
        }

        public void AddAffectsPlanItem(Link affectsPlanItem)
        {
            this._affectsPlanItems.Add(affectsPlanItem);
        }

        public void AddAffectsRequirement(Link affectsRequirement)
        {
            this._affectsRequirements.Add(affectsRequirement);
        }

        public void AddAffectsTestResult(Link affectsTestResult)
        {
            this._affectsTestResults.Add(affectsTestResult);
        }

        public void AddBlocksTestExecutionRecord(Link blocksTestExecutionRecord)
        {
            this._blocksTestExecutionRecords.Add(blocksTestExecutionRecord);
        }

        public void AddContributor(Uri contributor)
        {
            this._contributors.Add(contributor);
        }

        public void AddCreator(Uri creator)
        {
            this._creators.Add(creator);
        }

        public void AddDctermsType(string dctermsType)
        {
            this._dctermsTypes.Add(dctermsType);
        }

        public void AddImplementsRequirement(Link implementsRequirement)
        {
            this._implementsRequirements.Add(implementsRequirement);
        }

        public void AddRdfType(Uri rdfType)
        {
            this._rdfTypes.Add(rdfType);
        }

        public void AddRelatedChangeRequest(Link relatedChangeRequest)
        {
            this._relatedChangeRequests.Add(relatedChangeRequest);
        }

        public void AddRelatedResource(Link relatedResource)
        {
            this._relatedResources.Add(relatedResource);
        }

        public void AddRelatedTestCase(Link relatedTestCase)
        {
            this._relatedTestCases.Add(relatedTestCase);
        }

        public void AddRelatedTestExecutionRecord(Link relatedTestExecutionRecord)
        {
            this._relatedTestExecutionRecords.Add(relatedTestExecutionRecord);
        }

        public void AddRelatedTestPlan(Link relatedTestPlan)
        {
            this._relatedTestPlans.Add(relatedTestPlan);
        }

        public void AddRelatedTestScript(Link relatedTestScript)
        {
            this._relatedTestScripts.Add(relatedTestScript);
        }

        public void AddSubject(string subject)
        {
            this._subjects.Add(subject);
        }

        public void AddTestedByTestCase(Link testedByTestCase)
        {
            this._testedByTestCases.Add(testedByTestCase);
        }

        public void AddTracksChangeSet(Link tracksChangeSet)
        {
            this._tracksChangeSets.Add(tracksChangeSet);
        }

        public void AddTracksRequirement(Link tracksRequirement)
        {
            this._tracksRequirements.Add(tracksRequirement);
        }

        [OslcDescription("Change request is affected by a reported defect.")]
        [OslcName("affectedByDefect")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "affectedByDefect")]
        [OslcRange(CmConstants.TYPE_CHANGE_REQUEST)]
        [OslcReadOnly(false)]
        [OslcTitle("Affected By Defects")]
        public Link[] GetAffectedByDefects()
        {
            return this._affectedByDefects.ToArray();
        }

        [OslcDescription("Change request affects a plan item. ")]
        [OslcName("affectsPlanItem")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "affectsPlanItem")]
        [OslcRange(CmConstants.TYPE_CHANGE_REQUEST)]
        [OslcReadOnly(false)]
        [OslcTitle("Affects Plan Items")]
        public Link[] GetAffectsPlanItems()
        {
            return this._affectsPlanItems.ToArray();
        }

        [OslcDescription("Change request affecting a Requirement.")]
        [OslcName("affectsRequirement")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "affectsRequirement")]
        [OslcRange(CmConstants.TYPE_REQUIREMENT)]
        [OslcReadOnly(false)]
        [OslcTitle("Affects Requirements")]
        public Link[] GetAffectsRequirements()
        {
            return this._affectsRequirements.ToArray();
        }

        [OslcDescription("Associated QM resource that is affected by this Change Request.")]
        [OslcName("affectsTestResult")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "affectsTestResult")]
        [OslcRange(CmConstants.TYPE_TEST_RESULT)]
        [OslcReadOnly(false)]
        [OslcTitle("Affects Test Results")]
        public Link[] GetAffectsTestResults()
        {
            return this._affectsTestResults.ToArray();
        }

        [OslcDescription("Associated QM resource that is blocked by this Change Request.")]
        [OslcName("blocksTestExecutionRecord")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "blocksTestExecutionRecord")]
        [OslcRange(CmConstants.TYPE_TEST_EXECUTION_RECORD)]
        [OslcReadOnly(false)]
        [OslcTitle("Blocks Test Execution Records")]
        public Link[] GetBlocksTestExecutionRecords()
        {
            return this._blocksTestExecutionRecords.ToArray();
        }

        [OslcDescription("The date at which no further activity or work is intended to be conducted. ")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "closeDate")]
        [OslcReadOnly]
        [OslcTitle("Close DateTime?")]
        public DateTime? GetCloseDate()
        {
            return this._closeDate;
        }

        [OslcDescription("The person(s) who are responsible for the work needed to complete the change request.")]
        [OslcName("contributor")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "contributor")]
        [OslcRange(CmConstants.TYPE_PERSON)]
        [OslcTitle("Contributors")]
        public Uri[] GetContributors()
        {
            return this._contributors.ToArray();
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime? GetCreated()
        {
            return this._created;
        }

        [OslcDescription("Creator or creators of resource.")]
        [OslcName("creator")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "creator")]
        [OslcRange(CmConstants.TYPE_PERSON)]
        [OslcTitle("Creators")]
        public Uri[] GetCreators()
        {
            return this._creators.ToArray();
        }

        [OslcAllowedValue(new string[] { "Defect", "Task", "Story", "Bug Report", "Feature Request" })]
        [OslcDescription("A short string representation for the type, example 'Defect'.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public string[] GetDctermsTypes()
        {
            return this._dctermsTypes.ToArray();
        }

        [OslcDescription("Descriptive text (reference: Dublin Core) about resource represented as rich text in XHTML content.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "description")]
        [OslcTitle("Description")]
        [OslcValueType(Core.Model.ValueType.XMLLiteral)]
        public string GetDescription()
        {
            return this._description;
        }

        [OslcDescription("A series of notes and comments about this change request.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "discussedBy")]
        [OslcRange(CmConstants.TYPE_DISCUSSION)]
        [OslcTitle("Discussed By")]
        public Uri GetDiscussedBy()
        {
            return this._discussedBy;
        }

        [OslcDescription("A unique identifier for a resource. Assigned by the service provider when a resource is created. Not intended for end-user display.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "identifier")]
        [OslcReadOnly]
        [OslcTitle("Identifier")]
        public string GetIdentifier()
        {
            return this._identifier;
        }

        [OslcDescription("Implements associated Requirement.")]
        [OslcName("implementsRequirement")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "implementsRequirement")]
        [OslcRange(CmConstants.TYPE_REQUIREMENT)]
        [OslcReadOnly(false)]
        [OslcTitle("Implements Requirements")]
        public Link[] GetImplementsRequirements()
        {
            return this._implementsRequirements.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return this._instanceShape;
        }

        [OslcDescription("Timestamp last latest resource modification.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "modified")]
        [OslcReadOnly]
        [OslcTitle("Modified")]
        public DateTime? GetModified()
        {
            return this._modified;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return this._rdfTypes.ToArray();
        }

        [OslcDescription("This relationship is loosely coupled and has no specific meaning.")]
        [OslcName("relatedChangeRequest")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "relatedChangeRequest")]
        [OslcRange(CmConstants.TYPE_CHANGE_REQUEST)]
        [OslcReadOnly(false)]
        [OslcTitle("Related Change Requests")]
        public Link[] GetRelatedChangeRequests()
        {
            return this._relatedChangeRequests.ToArray();
        }

        [OslcDescription("Related OSLC resources of any type.")]
        [OslcName("relatedResource")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "relatedResource")]
        [OslcTitle("Related Resources")]
        public Link[] GetRelatedResources()
        {
            return this._relatedResources.ToArray();
        }

        [OslcDescription("Related QM test case resource.")]
        [OslcName("relatedTestCase")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "relatedTestCase")]
        [OslcRange(CmConstants.TYPE_TEST_CASE)]
        [OslcReadOnly(false)]
        [OslcTitle("Related Test Cases")]
        public Link[] GetRelatedTestCases()
        {
            return this._relatedTestCases.ToArray();
        }

        [OslcDescription("Related to a QM test execution resource.")]
        [OslcName("relatedTestExecutionRecord")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "relatedTestExecutionRecord")]
        [OslcRange(CmConstants.TYPE_TEST_EXECUTION_RECORD)]
        [OslcReadOnly(false)]
        [OslcTitle("Related Test Execution Records")]
        public Link[] GetRelatedTestExecutionRecords()
        {
            return this._relatedTestExecutionRecords.ToArray();
        }

        [OslcDescription("Related QM test plan resource.")]
        [OslcName("relatedTestPlan")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "relatedTestPlan")]
        [OslcRange(CmConstants.TYPE_TEST_PLAN)]
        [OslcReadOnly(false)]
        [OslcTitle("Related Test Plans")]
        public Link[] GetRelatedTestPlans()
        {
            return this._relatedTestPlans.ToArray();
        }

        [OslcDescription("Related QM test script resource.")]
        [OslcName("relatedTestScript")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "relatedTestScript")]
        [OslcRange(CmConstants.TYPE_TEST_SCRIPT)]
        [OslcReadOnly(false)]
        [OslcTitle("Related Test Scripts")]
        public Link[] GetRelatedTestScripts()
        {
            return this._relatedTestScripts.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return this._serviceProvider;
        }

        [OslcDescription("Short name identifying a resource, often used as an abbreviated identifier for presentation to end-users.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "shortTitle")]
        [OslcTitle("Short Title")]
        [OslcValueType(Core.Model.ValueType.XMLLiteral)]
        public string GetShortTitle()
        {
            return this._shortTitle;
        }

        [OslcDescription("Used to indicate the status of the change request based on values defined by the service provider. Most often a read-only property. Some possible values may include: 'Submitted', 'Done', 'InProgress', etc.")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "status")]
        [OslcTitle("Status")]
        public string GetStatus()
        {
            return this._status;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return this._subjects.ToArray();
        }

        [OslcDescription("Test case by which this change request is tested.")]
        [OslcName("testedByTestCase")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "testedByTestCase")]
        [OslcRange(CmConstants.TYPE_TEST_CASE)]
        [OslcReadOnly(false)]
        [OslcTitle("Tested by Test Cases")]
        public Link[] GetTestedByTestCases()
        {
            return this._testedByTestCases.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        [OslcValueType(Core.Model.ValueType.XMLLiteral)]
        public string GetTitle()
        {
            return this._title;
        }

        [OslcDescription("Tracks SCM change set resource.")]
        [OslcName("tracksChangeSet")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "tracksChangeSet")]
        [OslcRange(CmConstants.TYPE_CHANGE_SET)]
        [OslcReadOnly(false)]
        [OslcTitle("Tracks Change Sets")]
        public Link[] GetTracksChangeSets()
        {
            return this._tracksChangeSets.ToArray();
        }

        [OslcDescription("Tracks the associated Requirement or Requirement ChangeSet resources.")]
        [OslcName("tracksRequirement")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "tracksRequirement")]
        [OslcRange(CmConstants.TYPE_REQUIREMENT)]
        [OslcReadOnly(false)]
        [OslcTitle("Tracks Requirements")]
        public Link[] GetTracksRequirements()
        {
            return this._tracksRequirements.ToArray();
        }

        [OslcDescription("Whether or not the Change Request has been approved.")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "approved")]
        [OslcReadOnly]
        [OslcTitle("Approved")]
        public bool IsApproved()
        {
            return this._approved;
        }

        [OslcDescription("Whether or not the Change Request is completely done, no further fixes or fix verification is needed.")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "closed")]
        [OslcReadOnly]
        [OslcTitle("Closed")]
        public bool IsClosed()
        {
            return this._closed;
        }

        [OslcDescription("Whether or not the Change Request has been fixed.")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "fixed")]
        [OslcReadOnly]
        [OslcTitle("Fixed")]
        public bool IsFixed()
        {
            return this._isFixedValue;
        }

        [OslcDescription("Whether or not the Change Request in a state indicating that active work is occurring. If oslc_cm:inprogress is true, then oslc_cm:fixed and oslc_cm:closed must also be false.")]
        [OslcName("inprogress")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "inprogress")]
        [OslcReadOnly]
        [OslcTitle("In Progress")]
        public bool IsInProgress()
        {
            return this._inProgress;
        }

        [OslcDescription("Whether or not the Change Request has been reviewed.")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "reviewed")]
        [OslcReadOnly]
        [OslcTitle("Reviewed")]
        public bool IsReviewed()
        {
            return this._reviewed;
        }

        [OslcDescription("Whether or not the resolution or fix of the Change Request has been verified.")]
        [OslcPropertyDefinition(CmConstants.CHANGE_MANAGEMENT_NAMESPACE + "verified")]
        [OslcReadOnly]
        [OslcTitle("Verified")]
        public bool IsVerified()
        {
            return this._verified;
        }

        public void SetAffectedByDefects(Link[] affectedByDefects)
        {
            this._affectedByDefects.Clear();

            if (affectedByDefects != null)
            {
                this._affectedByDefects.AddAll(affectedByDefects);
            }
        }

        public void SetAffectsPlanItems(Link[] affectsPlanItems)
        {
            this._affectsPlanItems.Clear();

            if (affectsPlanItems != null)
            {
                this._affectsPlanItems.AddAll(affectsPlanItems);
            }
        }

        public void SetAffectsRequirements(Link[] affectsRequirements)
        {
            this._affectsRequirements.Clear();

            if (affectsRequirements != null)
            {
                this._affectsRequirements.AddAll(affectsRequirements);
            }
        }

        public void SetAffectsTestResults(Link[] affectsTestResults)
        {
            this._affectsTestResults.Clear();

            if (affectsTestResults != null)
            {
                this._affectsTestResults.AddAll(affectsTestResults);
            }
        }

        public void SetApproved(bool approved)
        {
            this._approved = approved;
        }

        public void SetBlocksTestExecutionRecords(Link[] blocksTestExecutionRecords)
        {
            this._blocksTestExecutionRecords.Clear();

            if (blocksTestExecutionRecords != null)
            {
                this._blocksTestExecutionRecords.AddAll(blocksTestExecutionRecords);
            }
        }

        public void SetClosed(bool closed)
        {
            this._closed = closed;
        }

        public void SetCloseDate(DateTime? closeDate)
        {
            this._closeDate = closeDate;
        }

        public void SetContributors(Uri[] contributors)
        {
            this._contributors.Clear();

            if (contributors != null)
            {
                this._contributors.AddAll(contributors);
            }
        }

        public void SetCreated(DateTime? created)
        {
            this._created = created;
        }

        public void SetCreators(Uri[] creators)
        {
            this._creators.Clear();

            if (creators != null)
            {
                this._creators.AddAll(creators);
            }
        }

        public void SetDctermsTypes(string[] dctermsTypes)
        {
            this._dctermsTypes.Clear();

            if (dctermsTypes != null)
            {
                this._dctermsTypes.AddAll(dctermsTypes);
            }
        }

        public void SetDescription(string description)
        {
            this._description = description;
        }

        public void SetDiscussedBy(Uri discussedBy)
        {
            this._discussedBy = discussedBy;
        }

        public void SetFixed(bool isFixed)
        {
            this._isFixedValue = isFixed;
        }

        public void SetIdentifier(string identifier)
        {
            this._identifier = identifier;
        }

        public void SetImplementsRequirements(Link[] implementsRequirements)
        {
            this._implementsRequirements.Clear();

            if (implementsRequirements != null)
            {
                this._implementsRequirements.AddAll(implementsRequirements);
            }
        }

        public void SetInProgress(bool inProgress)
        {
            this._inProgress = inProgress;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this._instanceShape = instanceShape;
        }

        public void SetModified(DateTime? modified)
        {
            this._modified = modified;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this._rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this._rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetRelatedChangeRequests(Link[] relatedChangeRequests)
        {
            this._relatedChangeRequests.Clear();

            if (relatedChangeRequests != null)
            {
                this._relatedChangeRequests.AddAll(relatedChangeRequests);
            }
        }

        public void SetRelatedResources(Link[] relatedResources)
        {
            this._relatedResources.Clear();

            if (relatedResources != null)
            {
                this._relatedResources.AddAll(relatedResources);
            }
        }

        public void SetRelatedTestCases(Link[] relatedTestCases)
        {
            this._relatedTestCases.Clear();

            if (relatedTestCases != null)
            {
                this._relatedTestCases.AddAll(relatedTestCases);
            }
        }

        public void SetRelatedTestExecutionRecords(Link[] relatedTestExecutionRecords)
        {
            this._relatedTestExecutionRecords.Clear();

            if (relatedTestExecutionRecords != null)
            {
                this._relatedTestExecutionRecords.AddAll(relatedTestExecutionRecords);
            }
        }

        public void SetRelatedTestPlans(Link[] relatedTestPlans)
        {
            this._relatedTestPlans.Clear();

            if (relatedTestPlans != null)
            {
                this._relatedTestPlans.AddAll(relatedTestPlans);
            }
        }

        public void SetRelatedTestScripts(Link[] relatedTestScripts)
        {
            this._relatedTestScripts.Clear();

            if (relatedTestScripts != null)
            {
                this._relatedTestScripts.AddAll(relatedTestScripts);
            }
        }

        public void SetReviewed(bool reviewed)
        {
            this._reviewed = reviewed;
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void SetShortTitle(string shortTitle)
        {
            this._shortTitle = shortTitle;
        }

        public void SetStatus(string status)
        {
            this._status = status;
        }

        public void SetSubjects(string[] subjects)
        {
            this._subjects.Clear();

            if (subjects != null)
            {
                this._subjects.AddAll(subjects);
            }
        }

        public void SetTestedByTestCases(Link[] testedByTestCases)
        {
            this._testedByTestCases.Clear();

            if (testedByTestCases != null)
            {
                this._testedByTestCases.AddAll(testedByTestCases);
            }
        }

        public void SetTitle(string title)
        {
            this._title = title;
        }

        public void SetTracksChangeSets(Link[] tracksChangeSets)
        {
            this._tracksChangeSets.Clear();

            if (tracksChangeSets != null)
            {
                this._tracksChangeSets.AddAll(tracksChangeSets);
            }
        }

        public void SetTracksRequirements(Link[] tracksRequirements)
        {
            this._tracksRequirements.Clear();

            if (tracksRequirements != null)
            {
                this._tracksRequirements.AddAll(tracksRequirements);
            }
        }

        public void SetVerified(bool verified)
        {
            this._verified = verified;
        }
    }
}
